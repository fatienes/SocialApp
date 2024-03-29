import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { NULL_EXPR } from "@angular/compiler/src/output/output_ast";
import { Observable, pipe, throwError } from "rxjs";
import { catchError } from "rxjs/operators";

export class ErrorInterceptor implements HttpInterceptor{
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {


    return next.handle(req)
    .pipe(catchError((error: HttpErrorResponse)=>{
      console.log(error);
      if(error.status ==400){
        if(error.error.errors){
          const serverError=error.error;
          let errorMessage='';


          for(const key in serverError.errors){
            errorMessage += serverError.errors[key] + '\n';
          }
          return throwError(errorMessage);

        }


        return throwError(error.error.Message);
      }
          if(error.status==401){
            return throwError(error.statusText);
          }
          if(error.status==500){
            return throwError(error.error.Message)
          }

    }))
  }

}
