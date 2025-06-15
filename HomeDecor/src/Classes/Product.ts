export class Product{
   
    constructor( public sku?:number,
                 public name?:string,
                 public description?:string,
                 public price?:number,
                 public imageUrl?:string
    ) {}
}