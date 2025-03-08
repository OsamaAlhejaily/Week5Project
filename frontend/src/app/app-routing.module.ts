import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { DocumentUploadComponent } from './components/document-upload/document-upload.component';
import { VerificationComponent } from './components/verification/verification.component';
import { NavigationComponent } from './components/navigation/navigation.component'; 

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    DocumentUploadComponent,
    VerificationComponent,
    NavigationComponent 
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
