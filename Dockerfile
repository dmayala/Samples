FROM microsoft/dotnet:1.1.2-sdk

COPY ./Samples /app
WORKDIR /app

RUN curl -sL https://deb.nodesource.com/setup_7.x | bash -
RUN apt-get install -y nodejs git sqlite3 libsqlite3-dev libunwind8 libssl-dev bzip2

RUN bash -c "npm install -g @angular/cli \
		&& dotnet restore \
		&& npm install --unsafe-perm=true"

# Configure the listening port to 5000
ENV ASPNETCORE_URLS http://*:5000

ENTRYPOINT ["dotnet", "run"]