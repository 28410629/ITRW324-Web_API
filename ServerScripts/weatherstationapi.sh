#! /bin/sh
#
### BEGIN INIT INFO
# Provides:          weatherstationapi.sh
# Required-Start:    $remote_fs $local_fs
# Required-Stop:     $remote_fs $local_fs
# Should-Start:
# Should-Stop:
# Default-Start:     2 3 4 5
# Default-Stop:      0 1 6
# Short-Description: AnchormenStations API
# Description:
### END INIT INFO

NAME=weatherstationapi

test -x $DAEMON || exit 0

case "$1" in
    start)
    echo -n "Starting AnchormenStations API: "
    start-stop-daemon --start --exec /usr/bin/dotnet /home/coen/WeatherStation_API/WeatherStationApi.dll
    echo "weatherstationapi."
    ;;
    stop)
    echo -n "Shutting AnchormenStations API:"
    start-stop-daemon --stop --oknodo --retry 30 --exec /usr/bin/dotnet /home/coen/WeatherStation_API/WeatherStationApi.dll
    echo "weatherstationapi."
    ;;

    restart)
    echo -n "Restarting AnchormenStations API: "
    start-stop-daemon --stop --oknodo --retry 30 --exec /usr/bin/dotnet /home/coen/WeatherStation_API/WeatherStationApi.dll
    start-stop-daemon --start --exec /usr/bin/dotnet /home/coen/WeatherStation_API/WeatherStationApi.dll
    echo "weatherstationapi."
    ;;

    *)
    echo "Usage: $0 {start|stop|restart}"
    exit 1
esac
exit 0

