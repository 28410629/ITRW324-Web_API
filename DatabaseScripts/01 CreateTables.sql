CREATE TABLE IF NOT EXISTS Readings (
    Id INT,
    AirPressure VARCHAR(255) NOT NULL,
    Humidity VARCHAR(255) NOT NULL,
    Light VARCHAR(255) NOT NULL,
    ReadingDateTime DATETIME NOT NULL,
    Temperature VARCHAR(255) NOT NULL,
    PRIMARY KEY (Id)
) 