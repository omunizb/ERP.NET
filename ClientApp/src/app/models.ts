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
