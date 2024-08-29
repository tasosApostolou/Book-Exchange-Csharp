import { Book } from "./book";
import { User } from "./user";

export interface Notification{
id:number;
user:User;
book:Book;
isSeen:boolean;
}
export interface Notifica{
    id:number;
    interestedUser:User
    user:User;
    book:Book;
    notificationType:string,
    isSeen:boolean;
    }

    export interface Notificat{
        id:number;
        interestedUser:User
        user:User;
        book:Book;
        type:string,
        isSeen:boolean;
        }