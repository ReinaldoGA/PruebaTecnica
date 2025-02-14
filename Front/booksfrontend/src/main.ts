import { bootstrapApplication } from '@angular/platform-browser';
import { provideAnimations } from '@angular/platform-browser/animations';
import { provideHttpClient } from '@angular/common/http';
import { AppComponent } from './app/app.component';
import { ApiService } from './app/services/api.service';  


bootstrapApplication(AppComponent, {
 
  providers:  [provideHttpClient(), ApiService,provideAnimations()]  
}).catch(err => console.error(err));
