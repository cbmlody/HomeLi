#!/usr/bin/env groovy

node {
    stage('Fetch') {
        git credentialsId: 'github-cbmlody', url: 'git@github.com:cbmlody/HomeLi.git'

        sh 'dotnet restore'
    }
    stage('Build backend') {
        sh 'dotnet sonarscanner begin /k:"homeli"'
        sh 'dotnet build HomeLi.sln'
        sh 'dotnet sonarscanner end'
    }
}