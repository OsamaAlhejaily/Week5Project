import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-document-upload',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './document-upload.component.html',
  styleUrls: ['./document-upload.component.css']
})
export class DocumentUploadComponent {
  uploadForm: FormGroup;
  selectedFile: File | null = null;

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.uploadForm = this.fb.group({
      title: ['', Validators.required],
      file: [null, Validators.required]
    });
  }

  onFileChange(event: any) {
    if (event.target.files.length > 0) {
      this.selectedFile = event.target.files[0];
      this.uploadForm.patchValue({ file: this.selectedFile });
    }
  }

  uploadDocument() {
    if (this.uploadForm.valid && this.selectedFile) {
      const formData = new FormData();
      
      formData.append('title', this.uploadForm.get('title')?.value);
      formData.append('file', this.selectedFile, this.selectedFile.name); 
  
      console.log('Uploading FormData:', formData.get('title'), formData.get('file')); 
  
      this.http.post('http://localhost:5206/api/documents', formData).subscribe(
        (response) => alert('Document uploaded successfully!'),
        (error) => {
          console.error('Upload failed:', error.error); 
          alert('Upload failed: ' + JSON.stringify(error.error)); 
        }
      );
    } else {
      alert('Please select a file and enter a title.');
    }
  }
  
  
}
