import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  message: string;

  log(message: string) {
    this.message = message;
  }
}
