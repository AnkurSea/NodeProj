pipeline {
    agent any

    environment {
        DOCKER_IMAGE = 'node-app-image'
        DOCKER_TAG = "${BUILD_NUMBER}"
        CONTAINER_NAME = 'node-app-container'
        PORT = '3000'
    }

    stages {
        stage('Checkout') {
            steps {
                echo 'Checking out code...'
                checkout scm
            }
        }

        stage('Build Docker Image') {
            steps {
                echo 'Building Docker image...'
                script {
                    bat "docker build -t ${DOCKER_IMAGE}:${DOCKER_TAG} ."
                    //bat "docker tag ${DOCKER_IMAGE}:${DOCKER_TAG} ${DOCKER_IMAGE}:latest"
                }
            }
        }

        // stage('Stop Previous Container') {
        //     steps {
        //         echo 'Stopping previous container...'
        //         script {
        //             bat '"'
        //                 if docker ps -a --format '{{.Names}}' | grep -q ${CONTAINER_NAME}; then
        //                     docker stop ${CONTAINER_NAME}
        //                     docker rm ${CONTAINER_NAME}
        //                 fi
        //             '"'
        //         }
        //     }
        // }

        stage('Run Docker Container') {
            steps {
                echo 'Running Docker container...'
                script {
                    bat "docker run -d -p ${PORT}:3000 --name ${CONTAINER_NAME} ${DOCKER_IMAGE}"
                }
            }
        }

        stage('Verify Deployment') {
            steps {
                echo 'Verifying deployment...'
                script {
                    bat """
                        sleep 5
                        if docker ps --filter "name=${CONTAINER_NAME}" --filter "status=running" | grep -q ${CONTAINER_NAME}; then
                            echo "Container is running successfully!"
                            docker ps --filter "name=${CONTAINER_NAME}"
                        else
                            echo "Container failed to start"
                            exit 1
                        fi
                    """
                }
            }
        }
    }

    post {
        success {
            echo "Deployment successful! App running on port ${PORT}"
        }
        failure {
            echo 'Deployment failed!'
            script {
                bat "docker logs ${CONTAINER_NAME} || true"
            }
        }
    }
}
