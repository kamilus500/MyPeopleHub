from flask import jsonify;
import requests;

api_url = 'https://localhost:7030'

def login(loginDto):
    try:
        response = requests.post(api_url + '/login', json=loginDto)

        if response.status_code == 200:
            data = response.json()
            return jsonify(data)
        else:
            return jsonify({'error': 'Błąd żądania HTTP'}), response.status_code
    except Exception as e:
        return jsonify({'error': str(e)}), 500
    
def register(registerDto):
    try:
        response = requests.post(api_url + '/register', json=registerDto)

        if response.status_code == 200:
            data = response.json()
            return jsonify(data)
        else:
            return jsonify({'error': 'Błąd żądania HTTP'}), response.status_code
    except Exception as e:
        return jsonify({'error': str(e)}), 500