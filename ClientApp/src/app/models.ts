export interface Product {  
    id: string;  
    name: string;  
    category: string;  
    description: string;  
    currentPrice: number;
    stock: number;
    purchases: number;
}

export interface Customer {  
    id: string;  
    name: string;  
    surname: string;  
    email: string;  
    firstPurchase: Date;
    latestPurchase: Date;
    totalExpenditure: number;
    totalPurchases: number;
    deliveryAddress: string;
    billingAddress: string;
    bankAccount: string;
}

export interface Employee {  
    id: string;  
    name: string;  
    surname: string;  
    hired: Date;
    departed: Date;
    salary: number;
    position: string;
}

export interface Order {
    id: string;
    customerId: number;
    productId: number;   
    employeeId: number;  
    time: Date;  
    quantity: number;
    price: number;
    priceVAT: number;
    state: string;
    priority: number;
    expectedDelivery: Date;
    delivered: Date;
}
