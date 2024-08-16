export class ParadaResponse {
    id: number ;
    name: string | undefined;
    latitude: number | undefined;
    longitude: number | undefined;
    
    constructor(
      id: number ,
      name: string,
      latitude: number,
      longitude: number
    ) {
      this.id = id;
      this.name = name;
      this.latitude = latitude;
      this.longitude = longitude;
    }
     
  }
  