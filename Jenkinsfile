node ('HomeLiBuild') {
    stage('Fetch') {
        git url: 'https://github.com/cbmlody/HomeLi.git'

        sh 'dotnet restore'
    }
    stage('Build backend') {
        sh 'dotnet sonarscanner begin /k:"homeli"'
        sh 'dotnet build HomeLi.sln'
        sh 'dotnet sonarscanner end'
    }
    stage('Build frontend') {
        sh 'cd HomeLiClient'
        sh 'npm install'
        sh 'ng build --prod'
    }
}