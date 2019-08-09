import { Component, OnInit, Injectable } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Component({
  selector: 'app-rmsapp',
  templateUrl: './rmsapp.component.html',
  styleUrls: ['./rmsapp.component.css']
})

@Injectable()
export class RmsappComponent implements OnInit {
  form: FormGroup;
  userForm: any;
  readonly rootUrl = 'https://localhost:44323'; // API URL
    public HttpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*'
    })
  };
  constructor(
    private formBuilder: FormBuilder,
    private http: HttpClient
  ) { }

  ngOnInit() {
    this.userForm = this.formBuilder.group({
      trainingname: ['', Validators.required],
      startdate: ['', [Validators.required]],
      enddate: ['', [Validators.required]]
    });
  }
  saveUser() {
    if (this.userForm.dirty && this.userForm.valid) {

      var body: Training = {
        Training_Name: this.userForm.value.trainingname,
        Training_Startdate: this.userForm.value.startdate,
        Training_Endate: this.userForm.value.enddate
      }

      const http$ = this.http.post<Training>(this.rootUrl + '/api/Trainings', JSON.stringify(body), this.HttpOptions);

      http$.subscribe(
        res => { alert('Data saved successfully and number of training days are :'+ res.numofDays); console.log('HTTP response', res) } ,
        err => { if (err.error.errorMessage!='There was an internal error, please contact to technical support.')alert(err.error.errorMessage); console.log('HTTP Error', err)},
        () => console.log('HTTP request completed.')
      );

     
    }
  }
}


export class Training {

  constructor(
    public Training_Name: string,
    public Training_Startdate:any,
    public Training_Endate: any,
    public numofDays?:number
  ) { }

}

export class ValidationService {
  static getValidatorErrorMessage(validatorName: string, validatorValue?: any) {
    let config = {
      'required': 'Required'     
    };

    return config[validatorName];
  }

 
}

