set DOCKER_BUILDKIT=0
set COMPOSE_DOCKER_CLI_BUILD=0


    docker build -t messages .
    docker run -p 80 --rm -it messages
    
    
    
 