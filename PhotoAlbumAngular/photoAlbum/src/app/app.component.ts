import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AlbumsComponent } from './albums/albums.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, AlbumsComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'photoAlbum';
}
