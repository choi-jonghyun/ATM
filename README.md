# ATM
주요 기능 (Features)

회원 가입 (Sign Up): 사용자가 아이디, 비밀번호, 이름을 입력하여 로컬에 JSON 파일로 계정 생성

로그인 (Log In): 저장된 계정 정보 확인 후 로그인

입금 (Deposit): 상세 금액 입력 또는 버튼으로 금액 선택 후 계좌에 입금

출금 (Withdraw): 계좌 잔액 내에서 금액을 출금

송금 (Remittance): 다른 사용자 계정으로 금액 이체

데이터 저장 및 로드 (Persistence): Application.persistentDataPath 경로에 JSON 파일로 유저 데이터 저장 및 로드

프로젝트 구조 (Project Structure)

ATM-main/</br>
├── Assets/</br>
│   ├── Scenes/</br>
│   │   └── SampleScene.unity       # 메인 씬</br>
│   └── Scripts/                   # C# 스크립트</br>
│       ├── GameManager.cs         # 싱글톤 관리, 데이터 저장/로드</br>
│       ├── UIManager.cs           # UI 텍스트 갱신 처리</br>
│       ├── PopupSignup.cs         # 회원 가입 UI 및 JSON 저장</br>
│       ├── PopupLogin.cs          # 로그인 UI 및 인증 처리</br>
│       ├── PopupBank.cs           # 입금/출금 UI 처리</br>
│       ├── Remittance.cs          # 송금 UI 처리</br>
│       └── UserData.cs            # 직렬화 가능한 유저 데이터 클래스</br>
├── ProjectSettings/               # 유니티 프로젝트 설정</br>
└── README.md                      # 프로젝트 정보 (이 파일)

요구사항 (Requirements)

Unity Editor 2022.3.17f1 (LTS) 이상

TextMesh Pro 패키지

사용법 (Usage)

회원 가입

Sign Up 버튼을 눌러 회원 가입 패널을 엽니다.

아이디, 비밀번호, 비밀번호 확인, 이름을 입력 후 가입 버튼을 클릭합니다.

로그인

가입한 계정 정보를 입력 후 로그인 버튼을 클릭합니다.

입금/출금

Deposit 또는 Withdraw 버튼을 클릭하여 각 패널을 엽니다.

미리 정의된 금액 버튼 또는 직접 입력 필드에 금액을 입력하여 처리합니다.

송금

Remittance 버튼을 클릭하여 송금 패널을 엽니다.

상대방 아이디와 송금 금액을 입력한 뒤 진행합니다.
