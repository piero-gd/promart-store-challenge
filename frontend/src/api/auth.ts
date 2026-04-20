import api from './axiosClient';
import type { LoginRequest, LoginResponse } from '../types';

export const login = async (credentials: LoginRequest): Promise<LoginResponse> => {
  const { data } = await api.post<LoginResponse>('/api/auth/login', credentials);
  return data;
};
