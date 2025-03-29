export interface WorldStats {
  numberOfCountries: number;
  totalArea: number;
  totalPopulation: number;
  independency: {
    independentCountries: number;
    dependentTerritories: number;
  };
  regionalStats: {
    area: {
        [key: string]: number;
    };
    population: {
        [key: string]: number;
    };
  };
}
