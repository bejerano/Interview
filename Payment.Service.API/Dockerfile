FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build-env
# ARG PASSWORD_ENV_SEEDED
WORKDIR /App



# Copy everything
COPY . ./

RUN apt-get update
RUN cd Payment.Service.API && dotnet tool update --global dotnet-ef
# RUN chmod u+x .aspnet/common.sh && chmod u+x .aspnet/ubuntu-create-dotnet-devcert.sh
# RUN .aspnet/ubuntu-create-dotnet-devcert.sh
# RUN dotnet dev-certs https --clean
#RUN dotnet dev-certs https --clean
# RUN dotnet dev-certs https -ep ./conf.d/https/dev_cert.pfx -p dev123
#RUN dotnet dev-certs https --trust --verbose
#RUN dotnet dev-certs https -ep ${HOME}/.aspnet/https/paymentapi.pfx -p dev123


# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal
WORKDIR /App
COPY --from=build-env /App/out .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "Payment.Service.API.dll"]
