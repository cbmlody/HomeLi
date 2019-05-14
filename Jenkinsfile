pipeline{
    agent any
    stages{
        stage("Preparation"){
            steps{
                echo "======== starting Preparation ========"
                git credentialsId: 'github-cbmlody', url: 'git@github.com:cbmlody/HomeLi.git'
                sh 'git clean -fdx'
                sh 'dotnet restore'
            }
            post{
                success{
                    echo "======== Preparation executed successfully ========"
                }
                failure{
                    echo "======== Preparation execution failed ========"
                }
            }
        }
        stage("Build") {
            steps{
                echo "======== starting Build ========"
                sh 'dotnet build HomeLi.sln'
            }
            post{
                success{
                    echo "======== Build executed successfully ========"
                }
                failure{
                    echo "======== Build execution failed ========"
                }
            }
        }
    }
    post{
        always{
            echo "======== always ========"
        }
        success{
            echo "======== pipeline executed successfully ========"
        }
        failure{
            echo "======== pipeline execution failed ========"
        }
    }
}