import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthBaseResponse } from '../models/shared/base-response.model';
import { LoginResponseModel, UserLoginModel, UserProfileModel, UserRegisterModel } from '@models';

@Injectable({
  providedIn: 'root'
})

export class UserAuthenticationService {
  private apiUrl = `${environment.API_BASE_URL}`;
  constructor(
    private http: HttpClient
  ) { }

  createAuthorizationHeader(headers: HttpHeaders) {
    const token = localStorage.getItem('token');
    console.warn(token);
    headers.set('Content-Type', 'application/json');
    headers.set('Authorization', `Bearer ${token}`);
    console.warn(headers);
  }

  public login(model: UserLoginModel): Observable<LoginResponseModel> {
    return this.http.post<LoginResponseModel>(`${this.apiUrl}/login`, model);
  }

  public registerUser(model: UserRegisterModel): Observable<AuthBaseResponse> {
    // const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.post<AuthBaseResponse>(`${this.apiUrl}/register`, model, {headers: headers});
  }

  public registerAdmin(model: UserRegisterModel): Observable<AuthBaseResponse> {
    // const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.post<AuthBaseResponse>(`${this.apiUrl}/register-admin`, model, {headers: headers});
  }

  public logout(id: string): Observable<string> {
    const headers = new HttpHeaders();
    this.createAuthorizationHeader(headers);
    return this.http.post<string>(`${this.apiUrl}/logout/${id}`, {});
  }

  public getUserProfileById(id: string) {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.get(`${this.apiUrl}/${id}`,
    { headers: headers});
  }

  public getAllUsers() {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.get(`${this.apiUrl}/listall`,
    { headers: headers});
  }

  // public updateUserProfile(id: string, model: UserProfileUpdateRequestModel): Observable<UserProfileModel> {
  //   const token = localStorage.getItem('token');
  //   const headers = new HttpHeaders({
  //     'Content-Type': 'application/json',
  //     'Authorization': `Bearer ${token}`
  //   });
  //   return this.http.put<UserProfileModel>(`${this.apiUrl}/${id}`, model,
  //   { headers: headers});
  // }

  public deleteUser(id: string) {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    });
    return this.http.delete(`${this.apiUrl}/${id}`,
    { headers: headers});
  }

}
