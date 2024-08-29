import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { UserService } from './user.service';
import { Notifica, Notification } from '../interfaces/notification';

const API_URL = `${environment.apiURL}/Notification`
@Injectable({
  providedIn: 'root'
})
export class NotificationService {
http:HttpClient = inject(HttpClient)

userService = inject(UserService)

createNotification(notification:JSON){
  console.log(`${this.userService.user().userId} poios`)
  console.log(`${notification} poios`)
return this.http.post<{notification: Notifica}>(`${API_URL}/CreateNotification/${this.userService.user().userId}`,notification)
}

updateNotificationStatus(notification:Notifica){
  return this.http.patch<{notification:Notification}>(`${API_URL}/NotificationPatch/${notification.id}`,notification)

  // (`https://localhost:7279/api/Notification/NotificationPatch/${notification.id}`,notification)

//`${API_URL}//NotificationPatch/${notification.id}`,notification
//https://localhost:7279/api/Notification/NotificationPatch/75
}

// getNotificationById(id:Number){
//   return this.http.get<{notification:Notifica}>(`${API_URL}/${id}`,{
//     headers: {
//       Accept:'application/json'
//     },
//   })
// }
}
