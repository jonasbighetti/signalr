import { Component, OnInit } from '@angular/core';
import {HubConnection, HubConnectionBuilder, LogLevel} from '@microsoft/signalr';
import {Message} from '../models/message.interface';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'signalr-example';

  private hubConnection: HubConnection;
  msgs: Message[] = [];

  ngOnInit(): void {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl('http://localhost:5000/signalr')
      .build();
    this.hubConnection
    .start()
    .then(() => console.log('Connection started'))
    .catch(err => console.log('Error while starting connection: ' + err));

    this.hubConnection.on('BroadcastMessage', (data: Message) => {
      this.msgs.push(data);
    });
  }
}
