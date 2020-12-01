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
    email: string; 
    hired: Date;
    departed: Date;
    salary: number;
    position: string;
    userName: string;
    normalizedUserName: string;
    normalizedEmail: string;
    emailConfirmed: boolean;
    passwordHash: string;
    securityStamp: string;
    concurrencyStamp: string;
    phoneNumber: string;
    phoneNumberConfirmed: boolean;
    twoFactorEnabled: boolean;
    lockoutEnd: Date;
    lockoutEnabled: boolean;
    accessFailedCount: number;
}

export interface Order {
    id: string;
    customerId: string;
    productId: string;   
    employeeId: string;
    time: Date;  
    quantity: number;
    price: number;
    priceVAT: number;
    state: string;
    priority: number;
    expectedDelivery: Date;
    delivered: Date;
}

export interface Stat {
    label: string;
    units: number;
    revenue: number;
}
