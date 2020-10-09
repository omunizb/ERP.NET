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

export interface Order {
    idOrder?: number;
    idCustomer: number;
    idProduct: number;   
    idEmployee?: number;  
    time: Date;  
    quantity: number;
    price: number;
    priceVAT: number;
    state: string;
    priority: number;
    expectedDelivery: Date;
    delivered: Date;
}
