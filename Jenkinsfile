#!/usr/bin/env groovy

node {
    stage('Fetch') {
        git credentialsId: 'github-cbmlody', url: 'git@github.com:cbmlody/HomeLi.git'

        sh 'dotnet restore'
    }
    stage('Build backend') {
        steps {
            sh 'dotnet sonarscanner begin /k:"homeli"'
        }
        steps {
            sh 'dotnet build HomeLi.sln'
        }
        steps {
            sh 'dotnet sonarscanner end'
        }
    }
}