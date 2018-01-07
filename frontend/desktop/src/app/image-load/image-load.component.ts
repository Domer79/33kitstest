import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FileInfo } from '../contracts/contracts';
import { environment } from '../../environments/environment';

class UploadObject{
  filename: string;
  data: Blob;
}

@Component({
  selector: 'app-image-load',
  templateUrl: './image-load.component.html',
  styleUrls: ['./image-load.component.scss']
})
export class ImageLoadComponent implements OnInit {

  constructor(
    private http: HttpClient
  ) { }

  ngOnInit() {
  }

  title = 'app';
  uri = `${environment.host}${environment.api}`;
  host = environment.host;
  files: UploadObject[] = [];
  fileinfos: FileInfo[];

  fileChange(event){
    for(let file of event.target.files){
      var reader = new FileReader()
      reader.onload = (ev:any) => {
        let object = new UploadObject();
        object.filename = file.name;
        object.data = new Blob([ev.target.result]);
        
        this.files.push(object);
      };

      reader.readAsArrayBuffer(file);
    };
  }

  filesubmit(event){
    console.log(this.files);
    let index = 1;
    var data = new FormData();
    for(let file of this.files){
      // var headers = new HttpHeaders();
      // headers.append('content-length', `${file.data.size}`);
      data.append(`file${index}`, file.data, file.filename);
      index++;
    }

    let headers = new HttpHeaders();
    // headers.append('content-type', 'multipart/form-data');
    headers.append('content-type', 'undefined');
    this.http.post("files/upload", data, {headers}).subscribe(res => {
      this.fileinfos = res as FileInfo[];
    });
  return false;
  }

}
