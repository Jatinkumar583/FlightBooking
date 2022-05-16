export class AirlineInventory{
    inventoryId: number=0;
    flightNumber: number=0;
    airlineId: number=0;
    airline:string="";
    fromPlace:string="";
    toPlace: string="";
    startDateTime: Date = new Date();
    endDateTime: Date = new Date();
    scheduledDays: string="";
    instrumentUsed: string="";
    totalBussClassSeats:number=0;
    totalNonBussClassSeats: number=0;
    ticketCost:number=0;
    numberOfRows: number=0;
    meal:string="";
}