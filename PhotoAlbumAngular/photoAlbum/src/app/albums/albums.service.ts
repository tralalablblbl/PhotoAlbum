import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';


import { Observable, catchError, map } from 'rxjs';

import { Album } from './album';


@Injectable()
export class AlbumsService {
  constructor(
    private http: HttpClient) {
  }

  getAlbum(albumId: number): Observable<Album[]> {
    return this.http.get<Album[]>(`https://jsonplaceholder.typicode.com/photos?albumId=${albumId}`);
  }
}
