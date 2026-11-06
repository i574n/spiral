program SpiralGenerated;
{$mode delphi}{$H+}
{$IFDEF CPUX86_64}{$OPTIMIZATION NOREGVAR}{$ENDIF}
{$MAXSTACKSIZE $10000000}
uses SysUtils, Math;
type
  TSpiralRc = class refc: LongInt; procedure DropFields; virtual; end;
  TFun0 = class;
  TFun0 = class(TSpiralRc)
    function Invoke(a0: LongInt): LongInt; virtual; abstract;
  end;
  Tf_c0 = class(TFun0) v0: LongInt; function Invoke(v1: LongInt): LongInt; override; end;
  TUS0 = record tag: LongInt; c1_0: TFun0; end;
procedure TSpiralRc.DropFields;
begin
end;
procedure SpiralRetain(o: TSpiralRc);
begin
  if o <> nil then Inc(o.refc);
end;
procedure SpiralRelease(o: TSpiralRc);
begin
  if o <> nil then begin Dec(o.refc); if o.refc < 0 then begin o.DropFields; o.Free; end; end;
end;
function SpiralKeep(o: TSpiralRc): TSpiralRc;
begin
  SpiralRetain(o); Result := o;
end;
function ClosureCreate0(v0: LongInt): TFun0; forward;
procedure SpiralRetain_TUS0(const x: TUS0); forward;
procedure SpiralRelease_TUS0(const x: TUS0); forward;
function SpiralKeep_TUS0(const x: TUS0): TUS0; forward;
function Tf_c0.Invoke(v1: LongInt): LongInt;
var
  v2: LongInt;
begin
  v2 := v1 + v0;
  Result := v2;
  SpiralRelease(Self);
end;
function ClosureCreate0(v0: LongInt): TFun0;
var c: Tf_c0;
begin
  c := Tf_c0.Create; c.v0 := v0;
  Result := c;
end;
function US0_Missing: TUS0;
begin
  Result.tag := 0; 
end;
function US0_Call(a0: TFun0): TUS0;
begin
  Result.tag := 1; Result.c1_0 := a0;
end;
procedure SpiralRetain_TUS0(const x: TUS0);
begin
  case x.tag of
    1: begin SpiralRetain(x.c1_0); end;
  end;
end;
procedure SpiralRelease_TUS0(const x: TUS0);
begin
  case x.tag of
    1: begin SpiralRelease(x.c1_0); end;
  end;
end;
function SpiralKeep_TUS0(const x: TUS0): TUS0;
begin
  SpiralRetain_TUS0(x); Result := x;
end;
function SpiralMain: LongInt;
var
  v0: LongInt;
  v1: TFun0;
  v2: Boolean;
  v5: TUS0;
  v6: TFun0;
  v7: LongInt;
  v8: Boolean;
begin
  v0 := 3;
  v1 := ClosureCreate0(v0);
  v2 := True;
  if v2 then begin
      SpiralRetain(v1);
      v5 := US0_Call(v1);
  end else begin
      v5 := US0_Missing;
  end;
  SpiralRelease(v1);
  case v5.tag of
      1: begin
          v6 := v5.c1_0;
          SpiralRetain(v6);
          SpiralRetain(v6);
          SpiralRelease_TUS0(v5);
          v7 := v6.Invoke(4);
          SpiralRelease(v6);
          v8 := v7 = 7;
          if v8 then begin
              Result := 0;
          end else begin
              Result := 1;
          end;
      end;
      0: begin
          SpiralRelease_TUS0(v5);
          Result := 1;
      end;
  end;
end;
var SpiralOutputBuffer: array[0..65535] of Char;
begin
  SetTextBuf(Output, SpiralOutputBuffer, SizeOf(SpiralOutputBuffer));
  SetExceptionMask([exInvalidOp, exDenormalized, exZeroDivide, exOverflow, exUnderflow, exPrecision]);
  Halt(SpiralMain);
end.
