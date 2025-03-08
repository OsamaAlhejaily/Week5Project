import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-verification',
  standalone: true,
  imports: [CommonModule, FormsModule], 
  templateUrl: './verification.component.html',
  styleUrls: ['./verification.component.css']
})
export class VerificationComponent {
  verificationCode: string = '';
  result: string = '';

  constructor(private http: HttpClient) {} 

  verifyDocument() {
    if (!this.verificationCode) {
      this.result = 'Please enter a verification code.';
      return;
    }

    this.http.post('http://localhost:5206/api/verify', { code: this.verificationCode }).subscribe(
      (response: any) => {
        this.result = response.message; 
      },
      (error) => {
        this.result = 'Invalid verification code';
        console.error('Verification failed:', error);
      }
    );
  }
}
