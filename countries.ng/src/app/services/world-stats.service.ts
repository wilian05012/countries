import { Injectable } from '@angular/core';
import { ApiClientService } from './api-client.service';
import { WorldStats } from '../core/world-stats';

@Injectable({
  providedIn: 'root'
})
export class WorldStatsService {

  constructor(private apiClientService: ApiClientService) { }

  public getWorldStats() :WorldStats {
    let worldStats: WorldStats = {
      numberOfCountries: 0,
      totalArea: 0,
      totalPopulation: 0,
      independency: {
        independentCountries: 0,
        dependentTerritories: 0
      },
      regionalStats: {
        area: {},
        population: {}
      }
    };

    this.apiClientService.getAllCountries().subscribe((countries) => {
      worldStats.numberOfCountries = countries.length;
      worldStats.totalArea = countries.reduce((total, country) => total + country.area, 0);
      worldStats.totalPopulation = countries.reduce((total, country) => total + country.population, 0);
      worldStats.independency.independentCountries = countries.filter(country => country.independent).length;
      worldStats.independency.dependentTerritories = countries.filter(country => !country.independent).length;

      worldStats.regionalStats.area = countries.reduce((acc: { [key: string]: number }, country) => {
        const key: string = country.region;
        if (!acc[key]) {
          acc[key] = 0;
        }
        acc[key] += country.area;
        return acc;
      }, {});

      worldStats.regionalStats.population = countries.reduce((acc: { [key: string]: number }, country) => {
        const key: string = country.region;
        if (!acc[key]) {
          acc[key] = 0;
        }
        acc[key] += country.population;
        return acc;
      }, {});
    });

    return worldStats;
  }
}
