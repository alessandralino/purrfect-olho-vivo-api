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

  export class Parada {
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


   
  export class ParadaFiltro {
    id? : number;
    nome?: string;
    latitude?: string;
    longitude?: string;
  
    constructor( id?: number, nome?: string, latitude?: string, longitude?: string) {
      this.id = id || undefined;
      this.nome = nome || '';
      this.latitude = latitude || '';
      this.longitude = longitude || '';
    }
   
  }
  