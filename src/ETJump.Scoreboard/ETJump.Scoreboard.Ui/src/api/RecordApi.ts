import { RecordCriteria } from '../criteria/RecordCriteria'
import { RecordModel } from '../models/RecordModel'
import { BaseApi } from "./BaseApi";

export class RecordApi extends BaseApi {
    constructor(baseUrl: string) {
        super(baseUrl);
    } 
        
    getRecord = (id: number): Promise<RecordModel> => {
        return this.fetch(`api/records/${id}`, "get", null);
    }
        
    getRecords = (criteria: RecordCriteria): Promise<RecordModel[]> => {
        return this.fetch(`api/records`, "get", criteria);
    }
        
    update = (id: number, model: RecordModel): Promise<RecordModel> => {
        return this.fetch(`api/records/${id}`, "put", model);
    }
}