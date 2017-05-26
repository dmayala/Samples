import { Injectable } from '@angular/core';
import { Http, Response, RequestOptions, URLSearchParams } from '@angular/http';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/finally';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';

export interface SamplesOptions {
    status?: number,
    name?: string
}

@Injectable()
export class SamplesService {
  private samplesUrl = 'api/samples';
  private statusesUrl = 'api/statuses';
  private usersUrl = 'api/users';

  constructor(private http: Http) {}

  getSamples(options: SamplesOptions = {}) {
    let params: URLSearchParams = new URLSearchParams();
    if (options.status) params.set('status', options.status.toString());
    if (options.name) params.set('name', options.name);

    let requestOptions = new RequestOptions();
    requestOptions.params = params;

    return this.http.get(this.samplesUrl, requestOptions)
      .map(this.extractData)
      .catch(this.handleError);
  }

  addSample(sample) {
    return this.http.post(this.samplesUrl, sample)
      .map(res =>  res.json() || {})
      .catch(this.handleError);
  }

  getStatuses() {
    return this.http.get(this.statusesUrl)
      .map(this.extractData)
      .catch(this.handleError);
  }

  getUsers() {
    return this.http.get(this.usersUrl)
      .map(this.extractData)
      .catch(this.handleError);
  }

  private extractData(res: Response) {
    let body = res.json();
    return body.data || [];
  }

  private handleError (error: Response | any) {
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.message || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} - ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }
    console.error(errMsg);
    return Observable.throw(errMsg);
  }

}
