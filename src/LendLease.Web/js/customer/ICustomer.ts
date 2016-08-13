/* Defines the customer entity */
export interface ICustomer {
    customerId: number;
    customerName: string;
}

export interface ITileViewModel {
    title: string;
    value: number;
    url: string;
    iconCssClass: string;
    colorCssClass: string;
}