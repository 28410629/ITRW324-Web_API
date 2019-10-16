```
api
|___delete
|___get
    |___readings
    |___locationreadings
    |___location
        |___day?Province= &City= &Date=
        |___week?Province= &City= &Date=
        |___month?Province= &City= &Date=
        |___year?Province= &City= &Date=
    |___rawreadings
        |___station
            |___day?StationId= &Date=
            |___week?StationId= &Date=
            |___month?StationId= &Date=
            |___year?StationId= &Date=
    |___stationlist
        |___all
    |___stationstatus
        |___station?StationIds= &Date=
    |___stationdetail
        |___station
            |___day?StationId= &Date=
            |___week?StationId= &Date=
            |___month?StationId= &Date=
            |___year?StationId= &Date=
    |___forecast
        |___station
            |___4day?StationId= &Date=
|___post
    |___reading
|___put
``` 
