import { Category } from "./Category"


export class Department {

    constructor(public id: number=0,
        public name: string="",
        public description: string="",
        public categories: Array<Category>=new Array<Category>) {
    }
}