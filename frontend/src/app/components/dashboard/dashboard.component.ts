import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common'; 
import { AsyncPipe, DatePipe } from '@angular/common'; 

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, AsyncPipe, DatePipe], 
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  documents: any[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.fetchDocuments();
  }

  fetchDocuments() {
    this.http.get<any[]>('http://localhost:5206/api/documents').subscribe(
      (data) => (this.documents = data),
      (error) => console.error('Error fetching documents', error)
    );
  }
}
