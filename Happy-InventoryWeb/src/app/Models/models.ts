export class CommonRequest {
  format: string | undefined;
  makeId: number | undefined;
  modelyear: number | undefined;
}

export class ResponseResult<T> {
  count: any | undefined;
  message: string | undefined;
  searchCriteria: string | undefined;
  data: any | undefined;
  status: any;
  totalRecords:any
  
}

export class GetAllMakesModel {
  make_ID: number | undefined;
  make_Name: string | undefined;
}

export class TypesForMakeModel {
  vehicleTypeId: number | undefined;
  vehicleTypeName: string | undefined;
}

export class ModelsForMakeIdYearModel {
  make_ID: number | undefined; 
  make_Name: string | undefined; 
  model_ID: number | undefined;
  model_Name: string | undefined;
}

export enum apiType{
  getAllMakes = 1,
  getVehicleTypesForMakeId = 2,
  getModelsForMakeIdYear = 3
}



export class User {
  email?: string = null!;
  name?: string = null!;
  role: number | undefined;
  active: number | undefined;
  password: string = null!;
  confirmPassword: string = null!;
  creationUser!: string;
  creationDate!: Date;
  modificationUser?: string;
  modificationDate?: Date;
}


export class Login {
  email?: string = null!;
  password: string = null!;
  token:string=null!;
}


export class warehouse {
  name?: string = null!;
  address: string = null!;
  city: string = null!;
  countryCode :string= null!;
  creationUser!: string;
  creationDate!: Date;
  modificationUser?: string;
  modificationDate?: Date;
}

export class WarehouseItem {
  name?: string = null!;
  SkuCode: string = null!;
  Qty: number| undefined; 
  CostPrice :number= null!;
  MsrpPrice!: number;
  WarehouseId!: number;
  creationDate!: Date;
  creationUser!: string;
  modificationUser?: string;
  modificationDate?: Date;
}

export interface SelectItem {
  label?: string;
  value: any;
}


export enum LookupValue {
  country = 1,
  Rules = 2
}