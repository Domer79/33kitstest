export class FileInfo{
    Id:string;
    Hash: string;
    FileName: string;
}

export class Menu
{
    Id: string;
    Date: Date;
    Descripttion: string;
}

export class Dish
{
    Id: string;
    Name: string;
    Description: string;
}

export class Product{
    Id: string;
    Name: string;
    Price: number;
    Description: string;
}

export class DishList{
    IdMenu: string;
    IdDish: string;
    DishCount: number;
}