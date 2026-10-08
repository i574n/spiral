program SpiralGenerated;
{$mode delphi}{$H+}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TUH0 = class;
  TFun0 = class;
  TFun0 = class
    function Invoke: TUH0; virtual; abstract;
  end;
  TUH0 = class tag: LongInt; c0_0: QWord; c0_1: TFun0; end;
  TClosure0 = class(TFun0) v0: QWord; function Invoke: TUH0; override; end;
function ClosureCreate0(v0: QWord): TFun0; forward;
function method0(v0: QWord): TUH0; forward;
function method1(v0: TUH0; v1: QWord): QWord; forward;
function UH0_0(a0: QWord; a1: TFun0): TUH0;
begin
  Result := TUH0.Create; Result.tag := 0; Result.c0_0 := a0; Result.c0_1 := a1;
end;
function UH0_1: TUH0;
begin
  Result := TUH0.Create; Result.tag := 1; 
end;
function TClosure0.Invoke: TUH0;
var
  v1: QWord;
begin
  v1 := v0 - 1;
  Result := method0(v1);
end;
function ClosureCreate0(v0: QWord): TFun0;
var c: TClosure0;
begin
  c := TClosure0.Create; c.v0 := v0;
  Result := c;
end;
function method0(v0: QWord): TUH0;
var
  v1: Boolean;
  v3: TFun0;
begin
  v1 := v0 = 0;
  if v1 then begin
      Result := UH0_1;
  end else begin
      v3 := ClosureCreate0(v0);
      Result := UH0_0(v0, v3);
  end;
end;
function method1(v0: TUH0; v1: QWord): QWord;
var
  v2: QWord;
  v3: TFun0;
  v4: TUH0;
  v5: QWord;
  tmp4: TUH0;
  tmp5: QWord;
begin
  while True do begin
      case v0.tag of
          0: begin
              v2 := v0.c0_0;
              v3 := v0.c0_1;
              v4 := v3.Invoke;
              v5 := v1 + v2;
              tmp4 := v4;
              tmp5 := v5;
              v0 := tmp4;
              v1 := tmp5;
              Continue;
          end;
          1: begin
              Result := v1;
              Exit;
          end;
      end;
  end;
end;
function SpiralMain: LongInt;
var
  v0: QWord;
  v1: TUH0;
  v2: QWord;
  v3: QWord;
  v4: LongInt;
  v5: LongInt;
  v6: LongInt;
  v7: LongInt;
  v8: LongInt;
begin
  v0 := 10;
  v1 := method0(v0);
  v2 := 0;
  v3 := method1(v1, v2);
  v4 := 5;
  v5 := LongInt(v3);
  v6 := v4 * 2;
  v7 := v4 + v6;
  v8 := v5 + v7;
  Result := v8;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  Halt(SpiralMain);
end.
