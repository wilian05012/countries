export interface Country {
    name: {
        common: string;
        official: string;
    };
    cca2: string;
    cca3: string;
    independent: boolean;
    capital: string;
    region: string;
    area: number;
    population: number;
    flags: {
        png: string;
        svg: string;
    };
}
