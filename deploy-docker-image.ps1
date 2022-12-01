docker build -t database-api-app . # create Docker image
docker tag database-api-app registry.heroku.com/database-api-app/web # create tag between Heroku image & local image

# Deploy image to Heroku
heroku login
heroku container:login
heroku container:push web -a database-api-app
heroku container:release web -a database-api-app

Write-Host -ForegroundColor Green "Deployment was successful!"