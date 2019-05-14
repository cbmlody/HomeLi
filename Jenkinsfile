pipeline{
    agent any
    stages{
        stage("Preparation"){
            steps{
                echo "------ starting Preparation ------"
                git credentialsId: 'github-cbmlody', url: 'git@github.com:cbmlody/HomeLi.git'
                sh 'git clean -fdx'
                sh 'dotnet restore'
            }
            post{
                success{
                    echo "------ Preparation executed successfully ------"
                }
                failure{
                    echo "------ Oh no... Preparation execution failed ------"
                }
            }
        }
        stage("Build") {
            steps{
                echo "------ start scanner ------"
                sh './dotnet-sonarscanner begin /k:"homeli"'
                echo "------ starting Build ------"
                sh 'dotnet build HomeLi.sln'
                echo "------ scanner end ------"
                sh './dotnet-sonarscanner end'
            }
            post{
                success{
                    echo "------ Build executed successfully ------"
                }
                failure{
                    echo "------ Oh no... Build execution failed ------"
                }
            }
        }
    }
    post{
        success{
            echo "------ Pipeline executed successfully ------"
        }
        failure{
            echo "------ Oh no... Pipeline execution failed ------"
        }
    }
}