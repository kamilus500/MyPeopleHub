import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserDto } from '../models/UserDto';
import { CreateFriendship } from '../models/CreateFriendship';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FriendsService {

  private apiUrl = 'http://localhost:5131';

  constructor(private httpClient: HttpClient) { }

  getAllFriends(userId: string): Observable<UserDto[]> {
    return this.httpClient.get<UserDto[]>(this.apiUrl + `/GetAllFriendsForUser/${userId}`);
  }

  createFriend(newFriend: CreateFriendship): Observable<string> {
    return this.httpClient.post<string>(this.apiUrl + '/CreateFriendship', newFriend);
  }
}
