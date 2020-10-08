export interface Product {  
    idProduct?: number;  
    name: string;  
    category?: string;  
    description?: string;  
    currentPrice: number;
    stock?: number;
    purchases: number;
}

export interface Customer {  
    idCustomer?: number;  
    name: string;  
    surname: string;  
    email: string;  
    firstPurchase?: Date;
    latestPurchase?: Date;
    totalExpenditure: number;
    totalPurchases: number;
    deliveryAddress: string;
    billingAddress: string;
    bankAccount: string;
}

export interface Employee {  
    idEmployee?: number;  
    name: string;  
    surname: string;  
    hired: Date;
    departed?: Date;
    salary: number;
    position: string;
}
