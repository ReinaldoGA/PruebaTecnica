import { bootstrapApplication } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
import { AppComponent } from './app/app.component';
import { ApiService } from './app/services/api.service';  


bootstrapApplication(AppComponent, {
  providers: [provideHttpClient(), ApiService]  
}).catch(err => console.error(err));
