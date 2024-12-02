import { ErrorHandler, Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { MatSnackBar } from '@angular/material/snack-bar'; // Optional, for better notifications

@Injectable({
  providedIn: 'root',
})
export class GlobalErrorHandlerService implements ErrorHandler {

  constructor(private snackBar: MatSnackBar) {}

  handleError(error: any): void {
    if (error instanceof HttpErrorResponse) {
      if (error.error?.detail) {
        this.showErrorMessage(error.error.detail);
      } else {
        this.showErrorMessage('An unexpected error occurred. Please try again later.');
      }
    } else {
      console.error('An unknown error occurred:', error);
      this.showErrorMessage('An unknown error occurred. Please try again later.');
    }
  }

  private showErrorMessage(message: string): void {
    this.snackBar.open(message, 'Close', {
      duration: 5000,
      panelClass: ['error-snackbar']
    });
  }
}
