import { ApplicationConfig } from '@angular/core';
import { provideHttpClient } from '@angular/common/http';
import { ApiService } from './services/api.service';

export const config: ApplicationConfig = {
  providers: [
    provideHttpClient(),  
    ApiService           
  ]
};
