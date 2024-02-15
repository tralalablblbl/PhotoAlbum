import { Component } from '@angular/core';

import { AlbumsService } from './albums.service';
import { Album } from './album';
import { Logger } from '../logger.service';
import {HttpClientModule} from '@angular/common/http';
import { NgFor, NgIf } from '@angular/common';
import { NgModel } from '@angular/forms';
import { FormsModule } from '@angular/forms';

@Component({
  standalone: true,
  selector: 'app-albums',
  templateUrl: './albums.component.html',
  styleUrls: ['./albums.component.css'],
  providers:  [ AlbumsService ],
  imports: [HttpClientModule, NgFor, FormsModule, NgIf]
})
export class AlbumsComponent {
  public albumId = 0;
  public albums: Album[] = [];

  constructor(
    private service: AlbumsService,
    private logger: Logger) {
  }

  loadAlbums() {
    this.service.getAlbum(this.albumId).subscribe((albums: Album[]) => {
        this.logger.log(`Fetched ${albums.length} albums.`);
        this.albums = albums; // fill albums
      });
  }
}
